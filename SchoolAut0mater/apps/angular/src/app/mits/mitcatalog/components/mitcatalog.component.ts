import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type { GetMITCatalogsInput, MITCatalogDto } from '../../../proxy/core-service/mits/models';
import { MITCatalogService } from '../../../proxy/core-service/controllers/mits/mitcatalog.service';
@Component({
  selector: 'app-mitcatalog',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './mitcatalog.component.html',
  styles: [],
})
export class MITCatalogComponent implements OnInit {
  data: PagedResultDto<MITCatalogDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetMITCatalogsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: MITCatalogDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: MITCatalogService,
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

    const setData = (list: PagedResultDto<MITCatalogDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetMITCatalogsInput;
  }

  buildForm() {
    const { parentCatalogCode, code, name, displayName, linkedFeatures, isFactory, isActive } =
      this.selected || {};

    this.form = this.fb.group({
      parentCatalogCode: [parentCatalogCode ?? null, [Validators.maxLength(20)]],
      code: [
        code ?? null,
        [Validators.required, Validators.minLength(3), Validators.maxLength(20)],
      ],
      name: [
        name ?? null,
        [Validators.required, Validators.minLength(3), Validators.maxLength(100)],
      ],
      displayName: [displayName ?? null, []],
      linkedFeatures: [
        linkedFeatures ?? null,
        [Validators.minLength(0), Validators.maxLength(250)],
      ],
      isFactory: [false, []],
      isActive: [true, []],
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
      ? this.service.update(this.selected.id, {
          ...this.form.value,
          concurrencyStamp: this.selected.concurrencyStamp,
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

  update(record: MITCatalogDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: MITCatalogDto) {
    this.confirmation
      .warn('CoreService::DeleteConfirmationMessage', 'CoreService::AreYouSure', {
        messageLocalizationParams: [],
      })
      .pipe(
        filter(status => status === Confirmation.Status.confirm),
        switchMap(() => this.service.delete(record.id))
      )
      .subscribe(this.list.get);
  }
}
