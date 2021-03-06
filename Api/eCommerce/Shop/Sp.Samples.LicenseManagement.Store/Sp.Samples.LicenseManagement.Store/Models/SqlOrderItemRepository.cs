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

using Sp.Samples.LicenseManagement.Store.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sp.Samples.LicenseManagement.Store.Models
{
	public class SqlOrderItemRepository:IOrderItemRepository
	{
		readonly Func<StoreDbEntities> _createContext;

		public SqlOrderItemRepository( Func<StoreDbEntities> createContext )
		{
			_createContext = createContext;
		}

		public IEnumerable<OrderItem> GetOrderItems()
		{
			var orderItemsList = new List<OrderItem>();
			using ( var context = _createContext() )
				orderItemsList = context.OrderItems.ToList();
			return orderItemsList;
		}

		public OrderItem TryGet( int id )
		{
			using ( var context = _createContext() )
			{
				OrderItem orderItem = context.OrderItems.Find( id );
				return orderItem;
			}
		}

		public OrderItem Add( OrderItem orderItem )
		{
			using ( var context = _createContext() )
			{
				context.OrderItems.Add( orderItem );
				context.SaveChanges();
				return orderItem;
			}
		}
	}
}