import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44322/',
  redirectUri: baseUrl,
  clientId: 'SchoolAut0mater_Angular',
  responseType: 'code',
  scope:
    'offline_access openid profile email phone AccountService IdentityService AdministrationService SaasService ProductService',
  requireHttps: true,
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'SchoolAut0mater',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44325',
      rootNamespace: 'SchoolAut0mater',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
    ProductService: {
      url: 'https://localhost:44325',
      rootNamespace: 'SchoolAut0mater',
    },
  },
} as Environment;
