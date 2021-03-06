﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShopingOnline.Web.ViewModels
{
    public class PostTagViewModel
    {
        public int PostID { set; get; }

        public string TagID { set; get; }

        public virtual PostViewModel PostViewModel { set; get; }

        public virtual TagViewModel TagViewModel { set; get; }
    }
}