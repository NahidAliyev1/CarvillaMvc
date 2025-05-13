using CarvillaMVC.MVC.Contexts;
using CarvillaMVC.MVC.Exceptions;
using CarvillaMVC.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CarvillaMVC.MVC.Services;

public class FeaturedCarsService
{
    private readonly AppDbContext _context;
    public FeaturedCarsService()
    {
        _context = new AppDbContext();
    }
    #region Read
    public List<FeaturedCars> GetAllFeaturedCars() 
    {
        List<FeaturedCars> featuredCars = _context.featuredCars.ToList();
        return featuredCars;


    }

    public FeaturedCars GetFeaturedCarsById(int id) 
    {
        FeaturedCars? featuredCars = _context.featuredCars.Find(id);
        if (featuredCars is not null)
        {
            return featuredCars;
        }
        throw new FeaturedCarsException($"Databasada {id} tapilmadi");

    }

    #endregion

    #region Create
    public void CreateFeaturedCars(FeaturedCars featuredCars) 
    {
        _context.featuredCars.Add(featuredCars);
        _context.SaveChanges();

    }
    #endregion

    #region Update
    public void UpdateFeaturedCars(int id,FeaturedCars updatefeaturedcars) 
    {
        if (id!=updatefeaturedcars.Id)
        {
            throw new FeaturedCarsException("Idler ust uste dusmur");
        }
        FeaturedCars? featuredCars = _context.featuredCars.AsNoTracking().SingleOrDefault(fc =>fc.Id==id);
        if (featuredCars is null)
        {
            throw new FeaturedCarsException($"Databasda bu {id } tapilmadi");
        }
        _context.featuredCars.Update(featuredCars);
        _context.SaveChanges();

    }
    #endregion

    #region Delete
    public void DeleteFeaturedCars(int id) 
    {
        FeaturedCars? featuredCars = _context.featuredCars.Find(id);
        if (featuredCars is not null)
        {
            _context.featuredCars.Remove(featuredCars);
            _context.SaveChanges()
;        }
        else
        {
            throw new FeaturedCarsException($"Databasada {id} tapilmadi");
        }


    }
    #endregion
}
