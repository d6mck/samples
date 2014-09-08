﻿/*
 * Copyright (c) Inish Technology Ventures Limited.  All rights reserved.
 * 
 * This code is licensed under the BSD 3-Clause License included with this source
 * 
 * ALSO SEE: https://github.com/SoftwarePotential/samples/blob/master/License.txt
 * 
 */

using System;
using System.Windows;
using System.Windows.Input;
using DemoApp.BusinessLogic;
using DemoApp.Common;

namespace DemoApp
{
	class MainModel : ViewModelBase
	{
		public ICommand RunFeatureCommand { get; set; }

		public MainModel()
		{
			RunFeatureCommand = new RelayCommand<int>( RunFeature, _ => true, Convert.ToInt32 );
		}

		static void RunFeature( int featureNumber )
		{
			switch ( featureNumber )
			{
				case 1: MyAlgorithms.AccessFeature1();
					break;
				case 2: MyAlgorithms.AccessFeature2();
					break;
				case 3: MyAlgorithms.AccessFeature3();
					break;
				default:
					throw new ArgumentOutOfRangeException( "featureNumber" );
			}
			MessageBox.Show( string.Format( "Feature {0} accessed successfully", featureNumber ), "Success", MessageBoxButton.OK, MessageBoxImage.Information );
		}
	}
}