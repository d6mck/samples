﻿/*
 * Copyright 2013 (c) Inish Technology Ventures Limited.  All rights reserved.
 * 
 * This code is licensed under the BSD 3-Clause License included with this source
 * 
 * ALSO SEE: https://github.com/SoftwarePotential/samples/wiki/License
 * 
 */

// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.

using System.Web.Mvc;
using Sp.Samples.LicenseManagement.Store.Models;
using Sp.Samples.LicenseManagement.Store.Services;
using System.Configuration;
using System.Collections.Generic;
using System;

namespace Sp.Samples.LicenseManagement.Store.Controllers
{
	//The purpose of this Controller is to perform administrative functions on the catalog of products 
	//offered by the Software Vendor. Ordinarily these administrative tasks would be restricted to 
	//authorized administrators only. However, for the purposes of simplicity in this demonstration of 
	//Software Potential's Web APIS, no authorization restrictions have been included.

	public class CatalogController : Controller
	{
		readonly CatalogService _catalogService;
		readonly LicensingBasisService _licenseTypeService;

		public CatalogController()
		{
			Func<StoreDbEntities> createStoreContext = () => new StoreDbEntities();
			var sqlRepository = new SqlCatalogRepository( createStoreContext );
			_catalogService = new CatalogService( sqlRepository );

			_licenseTypeService = new LicensingBasisService();
		}

		public ActionResult Index()
		{
			List<CatalogEntryModel> catalogEntryModels = new List<CatalogEntryModel>();

			foreach ( CatalogEntry entry in _catalogService.ListAll() )
			{
				var catalogEntryViewModel = entry.ToViewModel();
				if ( String.IsNullOrEmpty( catalogEntryViewModel.LicensingBasis ) )
					catalogEntryViewModel.LicensingBasis = "N/A";
				catalogEntryModels.Add( catalogEntryViewModel );
			}
			return View( catalogEntryModels );
		}

		public ActionResult Details( int id = 0 )
		{
			CatalogEntry catalogEntry = _catalogService.TryGet( id );
			CatalogEntryModel catalogEntryModel = catalogEntry.ToViewModel();
			if ( catalogEntry == null )
				return HttpNotFound();
			return View( catalogEntryModel );
		}

		public ActionResult Create()
		{
			CatalogEntryModel catalogEntryModel = new CatalogEntryModel();
			catalogEntryModel.LicensingBases = _licenseTypeService.GetLicensingBases();
			return View( catalogEntryModel );
		}

		[HttpPost]
		public ActionResult Create( CatalogEntryModel catalogEntryModel )
		{
			CatalogEntry entry = catalogEntryModel.ToServiceModel();
			if ( ModelState.IsValid )
			{
				_catalogService.Add( entry );
				return RedirectToAction( "Index" );
			}
			catalogEntryModel.LicensingBases = _licenseTypeService.GetLicensingBases();
			return View( catalogEntryModel );
		}

		public ActionResult Edit( int id = 0 )
		{
			CatalogEntry catalogEntry = _catalogService.TryGet( id );
			if ( catalogEntry == null )
				return HttpNotFound();
			CatalogEntryModel catalogEntryModel = catalogEntry.ToViewModel();
			catalogEntryModel.LicensingBases = _licenseTypeService.GetLicensingBases();
			return View( catalogEntryModel );
		}

		[HttpPost]
		public ActionResult Edit( CatalogEntryModel catalogEntryModel )
		{
			CatalogEntry entry = catalogEntryModel.ToServiceModel();
			if ( ModelState.IsValid )
			{
				_catalogService.Update( entry );
				return RedirectToAction( "Index" );
			}
			catalogEntryModel.LicensingBases = _licenseTypeService.GetLicensingBases();
			return View( catalogEntryModel );
		}

		public ActionResult Delete( int id = 0 )
		{
			CatalogEntry catalogEntry = _catalogService.TryGet( id );
			CatalogEntryModel catalogEntryModel = catalogEntry.ToViewModel();
			if ( catalogEntry == null )
				return HttpNotFound();
			return View( catalogEntryModel );
		}

		[HttpPost, ActionName( "Delete" )]
		public ActionResult DeleteConfirmed( int id )
		{
			CatalogEntry catalogEntry = _catalogService.TryGet( id );
			if ( catalogEntry != null )
				_catalogService.Delete( catalogEntry );
			return RedirectToAction( "Index" );
		}
	}

	static class CatalogEntryConversionExtensions
	{
		public static CatalogEntryModel ToViewModel( this CatalogEntry model )
		{
			CatalogEntryModel catalogEntryModel = new CatalogEntryModel
			{
				Id = model.Id,
				ProductName = model.ProductName,
				ProductVersion = model.ProductVersion,
				Blurb = model.Blurb,
				Price = model.Price,
				SkuId = model.SkuId,
				LicensingBasis = model.LicensingBasis
			};
			return catalogEntryModel;
		}

		public static CatalogEntry ToServiceModel( this CatalogEntryModel model )
		{
			CatalogEntry entry = new CatalogEntry
			{
				Id = model.Id,
				ProductName = model.ProductName,
				ProductVersion = model.ProductVersion,
				Blurb = model.Blurb,
				Price = model.Price,
				SkuId = model.SkuId,
				LicensingBasis = model.LicensingBasis
			};
			return entry;
		}
	}
}