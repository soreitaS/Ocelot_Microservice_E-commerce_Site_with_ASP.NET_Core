﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICommentService _commentService;

        public CommentController(IHttpClientFactory httpClientFactory, ICommentService commentService)
        {
            _httpClientFactory = httpClientFactory;
            _commentService = commentService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Listesi";
            ViewBag.v0 = "Yorum İşlemleri";

            var values = await _commentService.GetAllCommentAsync();
            return View(values);
        }

        [Route("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            await _commentService.DeleteCommentAsync(id);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateComment/{id}")]
        public async Task<IActionResult> UpdateComment(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Listesi";
            ViewBag.v0 = "Yorum İşlemleri";
            var values = await _commentService.GetByIdCommentAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateComment/{id}")]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            updateCommentDto.Status = true;
            await _commentService.UpdateCommentAsync(updateCommentDto);
            return RedirectToAction("Index", "Comment", new { area = "Admin" });
        }
    }
}
