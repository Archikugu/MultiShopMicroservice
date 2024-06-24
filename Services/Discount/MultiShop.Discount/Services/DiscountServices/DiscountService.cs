﻿using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos.DiscountCouponDtos;

namespace MultiShop.Discount.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly MultiShopDiscountDapperContext _context;

        public DiscountService(MultiShopDiscountDapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto)
        {
            string query = "insert into Coupons(Code, Rate, IsActive, ValidDate) values (@code, @rate, @isActive, @validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createDiscountCouponDto.Code);
            parameters.Add("@rate", createDiscountCouponDto.Rate);
            parameters.Add("@isActive", createDiscountCouponDto.IsActive);
            parameters.Add("@validDate", createDiscountCouponDto.ValidDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "Delete From Coupons where CouponID=@couponID";
            var parameters = new DynamicParameters();
            parameters.Add("@couponID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "Select * From Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDDiscountCouponDto> GetByIDDiscountCouponAsync(int id)
        {
            string query = "Select * From Coupons Where CouponID=@couponID";
            var parameters = new DynamicParameters();
            parameters.Add("@couponID", id);
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<GetByIDDiscountCouponDto>(query, parameters);
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCoupon)
        {
            string query = "Update Coupons Set Code=@code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate where CouponID=@couponID";

            var parameters = new DynamicParameters();
            parameters.Add("@code", updateDiscountCoupon.Code);
            parameters.Add("@rate", updateDiscountCoupon.Rate);
            parameters.Add("@isActive", updateDiscountCoupon.IsActive);
            parameters.Add("@validDate", updateDiscountCoupon.ValidDate);
            parameters.Add("@couponID", updateDiscountCoupon.CouponID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
