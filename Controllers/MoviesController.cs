﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Controllers;
using System.Data.Entity;
public class MoviesController : Controller
{
    private ApplicationDbContext _context;
    
    public MoviesController()
    {
        _context = new ApplicationDbContext();
    }
    protected override void Dispose(bool disposing)
    {
        _context.Dispose();
    }
    public ViewResult Index()
    {
        var movies = _context.Movies.Include(m => m.Genre).ToList();
        return View(movies);
    }

    public ActionResult Details(int id)
    {
       
        var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
        if (movie == null)
        {
            return HttpNotFound();
        }
        else
        {
            return View(movie);
        }
    }
          
 }