using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackEndL.Models;
using BlogBackEndL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace BlogBackEndL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        //Create a variable to hold our data
        private readonly BlogitemService _data;


        //Create a constructor
        public BlogController(BlogitemService dataFromService)
        {
            _data = dataFromService;
        }


        //Add blog items
        [HttpPost("AddBlogItem")]

        public bool AddBlogItem(BlogitemModel newBlogItem)
        {
            return _data.AddBlogItem(newBlogItem);

        }
        //Get all blog items
        [HttpGet("GetBlogItem")]

        public IEnumerable<BlogitemModel> GetAllBlogItems()
        {
            return _data.GetAllBlogItems();
        }

        //Get blog items by category
         [HttpGet("GetItemsByCategory/{Category}")]

        public IEnumerable<BlogitemModel> GetItemsByCategory(string Category)
        {
            return _data.GetItemsByCategory(Category);
        }
        //Get all blog items by tags
         [HttpGet("GetItemsByTag")]

        public List<BlogitemModel> GetItemsByTag(string Tag)
        {
            return _data.GetItemsByTag(Tag);
        }

        //Get all blog items by date
        [HttpGet("GetItemsByDate/{Date}")]
        
        public IEnumerable<BlogitemModel> GetItemsByDate(string Date)
        {
            return _data.GetItemsByDate(Date);
        }
        //Update blog items
        [HttpPost("UpdateBlogItems")]

         public bool UpdateBlogItems(BlogitemModel BlogUpdate)
         {
            return _data.UpdateBlogItems(BlogUpdate);
         }
        //Delete blog items
        [HttpPost("DeleteBlogItem/{BlogItemToDelete}")]

        public bool DeleteBlogItem(BlogitemModel BlogDelete)
        {
            return _data.DeleteBlogItem(BlogDelete);
        }

        //GetPublishedBlogItems
        [HttpGet("GetPublishedItems")]

        public IEnumerable<BlogitemModel> GetPublishedItems()
        {
            return _data.GetPublishedItems();
        }
    }
}