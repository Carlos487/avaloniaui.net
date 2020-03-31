using System.Collections.Generic;
using System.IO;
using AvaloniaUI.Homepage.Models;
using AvaloniaUI.Homepage.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AvaloniaUI.Homepage.Pages.Blog
{
    public class AllModel : PageModel
    {
        private const string BlogRelativePath = "blog";
        private readonly IWebHostEnvironment _env;

        public AllModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        public List<BlogIndexItem>? Index { get; private set; }

        public void OnGet()
        {
            var blogPath = Path.Combine(_env.WebRootPath, BlogRelativePath);
            var loader = new BlogPostLoader(_env, Url);
            Index = loader.LoadIndex(blogPath);
        }
    }
}
