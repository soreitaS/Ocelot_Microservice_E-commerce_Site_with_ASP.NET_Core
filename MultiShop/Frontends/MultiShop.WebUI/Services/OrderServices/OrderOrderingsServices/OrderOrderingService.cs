﻿using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.OrderServices.OrderOrderingsServices
{
    public class OrderOrderingService : IOrderOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderOrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"orderings/GetOrderingByUserId/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOrderingByUserIdDto>>(jsonData);
            return values;
        }
    }
}
