﻿using Store_Website.Application.Interfaces.Contexts;
using Store_Website.Common.Dto;
using Store_Website.Domain.Entities.Finances;
using System;

namespace Store_Website.Application.Services.Fainances.Commands.AddRequestPay
{
    public class AddRequestPayService : IAddRequestPayService
    {
        private readonly IDataBaseContext _context;
        public AddRequestPayService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRequestPayDto> Execute(int Amount, long UserId)
        {
            var user = _context.Users.Find(UserId);
            RequestPay requestPay = new RequestPay()
            {
                Amount = Amount,
                Guid = Guid.NewGuid(),
                IsPay = false,
                User = user,

            };
            _context.RequestPays.Add(requestPay);
            _context.SaveChanges();

            return new ResultDto<ResultRequestPayDto>()
            {
                Data = new ResultRequestPayDto
                {
                    guid = requestPay.Guid,
                    Amount = requestPay.Amount,
                    Email = user.Email,
                    RequestPayId = requestPay.Id,
                },
                IsSuccess = true,
            };
        }
    }
}
