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

namespace Sp.Samples.LicenseManagement.Store.Controllers
{
	// If TriggerReroutingToConfigurationErrorPageIfNecessaryByTriggeringConfigurationException triggers an exception, we want to redirect to the configuration info page
	// In a larger application, one would wish to apply this exception management on a more global basis in the FilterConfig
	[HandleError( ExceptionType = typeof( CredentialsNotConfiguredException ), View="ConfigurationError" )]
	public class HomeController : Controller
	{
        public ActionResult Index()
		{
			TriggerReroutingToConfigurationErrorPageIfNecessaryByTriggeringConfigurationException();
			return View();
        }

		static void TriggerReroutingToConfigurationErrorPageIfNecessaryByTriggeringConfigurationException()
		{
			SoftwarePotentialConfiguration.File.VerifyCredentialsAreConfigured();
		}
	}
}