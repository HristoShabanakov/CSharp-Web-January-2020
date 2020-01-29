﻿using IRunes.App.Extensions;
using IRunes.Data;
using IRunes.Models;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRunes.App.Controllers
{
    public class AlbumsController : BaseController
    {
        public IHttpResponse All(IHttpRequest httpRequest)
        {
            using (var context = new RunesDbContext())
            {
                ICollection<Album> allAlbums = context.Albums.ToList();

                if(allAlbums.Count ==0)
                {
                    this.ViewData["Albums"] = "There are currently no albums.";
                }

                else
                {
                    this.ViewData["Albums"] = 
                        string.Join("<br />",
                        context.Albums.Select(album => album.ToHtmlAll()).ToList());
                }

                return this.View();
            }
        }

        public IHttpResponse Create(IHttpRequest httpRequest)
        {
            return this.View();
        }

        public IHttpResponse Details(IHttpRequest httpRequest)
        {
            return this.View();
        }
    }
}
