using api.Data;
using api.DTOs.Comment;
using api.Extensions;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/Comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _CommentRepo;

        private readonly IStockrepository _StockRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFMPService _fMPService;
        public CommentController(ICommentRepository CommentRepo , IStockrepository stockRepo, UserManager<AppUser> userManager, IFMPService fMPService)
        {
            _CommentRepo = CommentRepo;
            _StockRepo = stockRepo;
            _userManager = userManager;
            _fMPService = fMPService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllComments([FromQuery] CommentQueryObject queryObject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Comments = await _CommentRepo.GetCommentsAsync(queryObject);

            var CommentsDTO = Comments.Select(s => s.ToCommentDTO());

            return Ok(CommentsDTO);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetCommentById([FromRoute]int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Comment = await _CommentRepo.GetStockByIdAsync(Id);

            if(Comment == null)
                return NotFound($"There is no Id = {Id} in Database");

            return Ok(Comment.ToCommentDTO());
        }

        [HttpPost("{symbol:alpha}")]
        public async Task<IActionResult> CreateComment([FromRoute] string symbol, [FromBody] CreateCommentDTO CommentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stock = await _StockRepo.GetBySymbolAsync(symbol);

            if(stock == null)
            {
                stock = await _fMPService.FindStockBySymbleAsync(symbol);
                if (stock == null)
                    return BadRequest("This stock dose not exists");
                else
                {
                    await _StockRepo.CreateStockAsync(stock);
                }

            }

            if (!await _StockRepo.StockExists(stock.StockId))
                return NotFound($"There is no Id = {stock.StockId} in Database");
            var userName = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(userName);



            var CommentModle = CommentDto.ToCreateCommentDTO(stock.StockId);

            CommentModle.AppuserId = appUser.Id;
            await _CommentRepo.CreateCommentAsync(CommentModle);
            return Ok(CommentModle.ToCommentDTO());
        }

        [HttpPut("{Id:int}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int Id , UpdateCommentDTO updateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Comment = await _CommentRepo.UpdateCommentAsync(Id, updateDTO.ToUpdateCommentDTO());

            if (Comment == null)
                return NotFound($"There is no Id = {Id} in Database");

            return Ok(Comment.ToCommentDTO());

        }

        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Result =  await _CommentRepo.DeleteCommentAsync(Id);

            if (Result == null)
                return NotFound($"There is no Id = {Id} in Database");

            return NoContent();
        }
    }
}
