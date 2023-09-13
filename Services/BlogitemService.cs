using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackEndL.Models;
using BlogBackEndL.Services.Context;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BlogBackEndL.Services
{
    public class BlogitemService
    {

        //create a variable data _context
        private readonly DataContext _context;

        //Constructor
        public BlogitemService(DataContext context)
        {
            _context = context;
        }

        public bool AddBlogItem(BlogitemModel newBlogItem)
        {
            bool result = false;
            _context.Add(newBlogItem);

         result = _context.SaveChanges() != 0;
         return result;
        }

        public bool DeleteBlogItem(BlogitemModel BlogDelete)
        {
            _context.Update<BlogitemModel>(BlogDelete);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<BlogitemModel> GetAllBlogItems()
        {
            return _context.BlogInfo;
        }

        public IEnumerable<BlogitemModel> GetItemsByCategory(string Category)
        {
            return _context.BlogInfo.Where(item => item.Category == Category);
        }

        public IEnumerable<BlogitemModel> GetItemsByDate(string Date)
        {
            return _context.BlogInfo.Where(item => item.Date == Date);
        }

        public List<BlogitemModel> GetItemsByTag(string Tag)
        {
            //this will create a tag for our items Ex: "Tag1, Tag2, Tag3"
          List<BlogitemModel> AllBlogsWithTag = new List<BlogitemModel>();
          var allItems = GetAllBlogItems().ToList();//Ex Tag: {Tag: "Tag1",Tag: "Tag2", Tag: "Tag3"}
          for(int i = 0; i < allItems.Count; i++)
          {
           BlogitemModel Item = allItems[i];
           var itemArr = Item.Tag.Split(','); //{"Tag1", "Tag2"}

           for(int j = 0; j < itemArr.Length; j++)
           {
            if(itemArr[j].Contains(Tag))
            {
                AllBlogsWithTag.Add(Item);
            }
           }
          }
          return AllBlogsWithTag;
        }

        public bool UpdateBlogItems(BlogitemModel BlogUpdate)
        {
            _context.Update<BlogitemModel>(BlogUpdate);
            return _context.SaveChanges() !=0 ;
        }

        public IEnumerable<BlogitemModel> GetPublishedItems()
        {
            return _context.BlogInfo.Where(item => item.IsPublished);
        }
    }
}

