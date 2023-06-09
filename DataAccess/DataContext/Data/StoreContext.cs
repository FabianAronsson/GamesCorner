﻿using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataContext.Data
{
	public class StoreContext :DbContext
	{
		public StoreContext(DbContextOptions<StoreContext> options) : base(options)
		{
			
		}

		public DbSet<OrderModel> Orders { get; set; }
		public DbSet<ProductModel> Products { get; set; }
        public DbSet<EventModel> Events { get; set; }
		public DbSet<ReviewModel> Reviews { get; set; }
		public DbSet<UserEventModel> EventUsers { get; set; }

    }
}
