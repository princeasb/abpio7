import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
  GetMITItemsInput,
  MITItemWithNavigationPropertiesDto,
} from '../../../proxy/core-service/mits/models';
import { MITItemService } from '../../../proxy/core-service/controllers/mits/mititem.service';
@Component({
  selector: 'app-mititem',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './mititem.component.html',
  styles: [],
})
export class MITItemComponent implements OnInit {
  data: PagedResultDto<MITItemWithNavigationPropertiesDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetMITItemsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: MITItemWithNavigationPropertiesDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: MITItemService,
    private confirmation: ConfirmationService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    const getData = (query: ABP.PageQueryParams) =>
      this.service.getList({
        ...query,
        ...this.filters,
        filterText: query.filter,
      });

    const setData = (list: PagedResultDto<MITItemWithNavigationPropertiesDto>) =>
      (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetMITItemsInput;
  }

  buildForm() {
    const {
      code,
      name,
      displayName,
      databaseValue,
      displayValue,
      sortOrder,
      isFactory,
      isActive,
      mitCatalogId,
    } = this.selected?.mitItem || {};

    this.form = this.fb.group({
      code: [
        code ?? null,
        [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(20),
          Validators.pattern('[a-zA-Z0-9.-]*'),
        ],
      ],
      name: [
        name ?? null,
        [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(100),
          Validators.pattern('[a-zA-Z0-9\\-_ .]*'),
        ],
      ],
      displayName: [displayName ?? null, []],
      databaseValue: [
        databaseValue ?? null,
        [
          Validators.required,
          Validators.minLength(1),
          Validators.maxLength(50),
          Validators.pattern('[a-zA-Z0-9\\-_ .]*'),
        ],
      ],
      displayValue: [
        displayValue ?? null,
        [
          Validators.required,
          Validators.minLength(1),
          Validators.maxLength(50),
          Validators.pattern('[a-zA-Z0-9\\-_ .]*'),
        ],
      ],
      sortOrder: [sortOrder ?? null, []],
      isFactory: [false, []],
      isActive: [true, []],
      mitCatalogId: [mitCatalogId ?? null, [Validators.required]],
    });
  }

  hideForm() {
    this.isModalOpen = false;
    this.form.reset();
  }

  showForm() {
    this.buildForm();
    this.isModalOpen = true;
  }

  submitForm() {
    if (this.form.invalid) return;

    const request = this.selected
      ? this.service.update(this.selected.mitItem.id, {
          ...this.form.value,
          concurrencyStamp: this.selected.mitItem.concurrencyStamp,
        })
      : this.service.create(this.form.value);

    this.isModalBusy = true;

    request
      .pipe(
        finalize(() => (this.isModalBusy = false)),
        tap(() => this.hideForm())
      )
      .subscribe(this.list.get);
  }

  create() {
    this.selected = undefined;
    this.showForm();
  }

  update(record: MITItemWithNavigationPropertiesDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: MITItemWithNavigationPropertiesDto) {
    this.confirmation
      .warn('CoreService::DeleteConfirmationMessage', 'CoreService::AreYouSure', {
        messageLocalizationParams: [],
      })
      .pipe(
        filter(status => status === Confirmation.Status.confirm),
        switchMap(() => this.service.delete(record.mitItem.id))
      )
      .subscribe(this.list.get);
  }

  exportToExcel() {
    this.isExportToExcelBusy = true;
    this.service
      .getDownloadToken()
      .pipe(
        switchMap(({ token }) =>
          this.service.getListAsExcelFile({ downloadToken: token, filterText: this.list.filter })
        ),
        finalize(() => (this.isExportToExcelBusy = false))
      )
      .subscribe(result => {
        downloadBlob(result, 'MITItem.xlsx');
      });
  }
}
