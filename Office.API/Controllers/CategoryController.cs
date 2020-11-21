﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Office.API.DTOs;
using Office.Core.Models;
using Office.Core.Services;

namespace Office.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET :> Calling the controller will give following
        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            // Entites should not be return Data Transfer Objects should be returned
            var categories = await _categoryService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return Ok(result);
        }

        //GET :> /api/Category/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsyn(id);
            var result = _mapper.Map<CategoryDTO>(category);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDTO categoryDTO)
        {
            var categoryToSave = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDTO));
            // null => URL of the newly added category
            return Created(string.Empty, _mapper.Map<CategoryDTO>(categoryToSave));
        }
         
    }
}
