﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Office.Web.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace Office.Web.ApiService
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;
        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            IEnumerable<CategoryDto> categoryDto;

            var response = await _httpClient.GetAsync("category");

            // ** Status Code : 400-404 --> User related, 500-504 --> Server Related,  200-204 ---> Sucess Postive Response
            if (response.IsSuccessStatusCode)
            {
                categoryDto = JsonConvert
                    .DeserializeObject<IEnumerable<CategoryDto>>(
                    await response.Content.ReadAsStringAsync());
            }
            else
            {
                categoryDto = null;
            }
            return categoryDto;
        }

        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("category", stringContent);

            if (response.IsSuccessStatusCode)
            {
                categoryDto = JsonConvert
                   .DeserializeObject<CategoryDto>(
                   await response.Content.ReadAsStringAsync());
                return categoryDto;
            }
            else
            {
                // ** Log
                return null;
            }
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"category/{id}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert
                   .DeserializeObject<CategoryDto>(
                   await response.Content.ReadAsStringAsync());
            }
            else
            {
                // ** Log
                return null;
            }
        }

        public async Task<bool> Update(CategoryDto categoryDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("category", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"category/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
