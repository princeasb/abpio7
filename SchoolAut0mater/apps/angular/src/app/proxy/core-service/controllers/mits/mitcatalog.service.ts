import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { GetMITCatalogsInput, MITCatalogCreateDto, MITCatalogDto, MITCatalogUpdateDto } from '../../mits/models';

@Injectable({
  providedIn: 'root',
})
export class MITCatalogService {
  apiName = 'CoreService';
  

  create = (input: MITCatalogCreateDto) =>
    this.restService.request<any, MITCatalogDto>({
      method: 'POST',
      url: '/api/core-service/mitcatalogs',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: number) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/core-service/mitcatalogs/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: number) =>
    this.restService.request<any, MITCatalogDto>({
      method: 'GET',
      url: `/api/core-service/mitcatalogs/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: GetMITCatalogsInput) =>
    this.restService.request<any, PagedResultDto<MITCatalogDto>>({
      method: 'GET',
      url: '/api/core-service/mitcatalogs',
      params: { filterText: input.filterText, parentCatalogCode: input.parentCatalogCode, code: input.code, name: input.name, displayName: input.displayName, linkedFeatures: input.linkedFeatures, isFactory: input.isFactory, isActive: input.isActive, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: number, input: MITCatalogUpdateDto) =>
    this.restService.request<any, MITCatalogDto>({
      method: 'PUT',
      url: `/api/core-service/mitcatalogs/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
