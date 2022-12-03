import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { GetMITItemsInput, MITItemCreateDto, MITItemDto, MITItemExcelDownloadDto, MITItemUpdateDto, MITItemWithNavigationPropertiesDto } from '../../mits/models';
import type { DownloadTokenResultDto, LookupDto, LookupRequestDto } from '../../shared/models';

@Injectable({
  providedIn: 'root',
})
export class MITItemService {
  apiName = 'CoreService';
  

  create = (input: MITItemCreateDto) =>
    this.restService.request<any, MITItemDto>({
      method: 'POST',
      url: '/api/core-service/mititems',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: number) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/core-service/mititems/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: number) =>
    this.restService.request<any, MITItemDto>({
      method: 'GET',
      url: `/api/core-service/mititems/${id}`,
    },
    { apiName: this.apiName });
  

  getDownloadToken = () =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/core-service/mititems/download-token',
    },
    { apiName: this.apiName });
  

  getList = (input: GetMITItemsInput) =>
    this.restService.request<any, PagedResultDto<MITItemWithNavigationPropertiesDto>>({
      method: 'GET',
      url: '/api/core-service/mititems',
      params: { filterText: input.filterText, code: input.code, name: input.name, displayName: input.displayName, databaseValue: input.databaseValue, displayValue: input.displayValue, sortOrderMin: input.sortOrderMin, sortOrderMax: input.sortOrderMax, isFactory: input.isFactory, isActive: input.isActive, mitCatalogId: input.mitCatalogId, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  getListAsExcelFile = (input: MITItemExcelDownloadDto) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/core-service/mititems/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName });
  

  getMITCatalogLookup = (input: LookupRequestDto) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>({
      method: 'GET',
      url: '/api/core-service/mititems/mitcatalog-lookup',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  getWithNavigationProperties = (id: number) =>
    this.restService.request<any, MITItemWithNavigationPropertiesDto>({
      method: 'GET',
      url: `/api/core-service/mititems/with-navigation-properties/${id}`,
    },
    { apiName: this.apiName });
  

  update = (id: number, input: MITItemUpdateDto) =>
    this.restService.request<any, MITItemDto>({
      method: 'PUT',
      url: `/api/core-service/mititems/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
