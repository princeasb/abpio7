import type { EntityDto, FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetMITCatalogsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  parentCatalogCode?: string;
  code?: string;
  name?: string;
  displayName?: string;
  linkedFeatures?: string;
  isFactory?: boolean;
  isActive?: boolean;
}

export interface GetMITItemsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  code?: string;
  name?: string;
  displayName?: string;
  databaseValue?: string;
  displayValue?: string;
  sortOrderMin?: number;
  sortOrderMax?: number;
  isFactory?: boolean;
  isActive?: boolean;
  mitCatalogId?: number;
}

export interface MITCatalogCreateDto {
  parentCatalogCode?: string;
  code: string;
  name: string;
  displayName?: string;
  linkedFeatures?: string;
  isFactory?: boolean;
  isActive?: boolean;
}

export interface MITCatalogDto extends EntityDto<number> {
  parentCatalogCode?: string;
  code: string;
  name: string;
  displayName?: string;
  linkedFeatures?: string;
  isFactory?: boolean;
  isActive?: boolean;
  concurrencyStamp?: string;
}

export interface MITCatalogUpdateDto {
  parentCatalogCode?: string;
  code: string;
  name: string;
  displayName?: string;
  linkedFeatures?: string;
  isFactory?: boolean;
  isActive?: boolean;
  concurrencyStamp?: string;
}

export interface MITItemCreateDto {
  code: string;
  name: string;
  displayName?: string;
  databaseValue: string;
  displayValue: string;
  sortOrder?: number;
  isFactory?: boolean;
  isActive?: boolean;
  mitCatalogId: number;
}

export interface MITItemDto extends FullAuditedEntityDto<number> {
  code: string;
  name: string;
  displayName?: string;
  databaseValue: string;
  displayValue: string;
  sortOrder?: number;
  isFactory?: boolean;
  isActive?: boolean;
  mitCatalogId: number;
  concurrencyStamp?: string;
}

export interface MITItemExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface MITItemUpdateDto {
  code: string;
  name: string;
  displayName?: string;
  databaseValue: string;
  displayValue: string;
  sortOrder?: number;
  isFactory?: boolean;
  isActive?: boolean;
  mitCatalogId: number;
  concurrencyStamp?: string;
}

export interface MITItemWithNavigationPropertiesDto {
  mitItem: MITItemDto;
  mitCatalog: MITCatalogDto;
}
