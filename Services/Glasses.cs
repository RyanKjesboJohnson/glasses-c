using ContosoPizza.Models;

namespace ContosoPizza.Services;

public static class GlassService
{
    static List<Glass> Glasses { get; }
    static int nextId = 4;
    static GlassService()
    {
        Glasses = new List<Glass>
        {
            new Glass {Id = 1, Name = "Ray-Ban Clubmaster", Color= "Brown / Gold", Shape= "browline"},
            new Glass {Id = 2, Name = "Ottoto Bellona", Color= "Pink / Gold", Shape= "Oval"},
            new Glass {Id = 3, Name = "Oakley Socket 5.5", Color= "Gunmetal", Shape= "Rectangle"},
        };
    }

    public static List<Glass> GetAll() => Glasses;

    public static Glass? Get(int id) => Glasses.FirstOrDefault(p => p.Id == id);

    public static void Add(Glass glass)
    {
        glass.Id = nextId++;
        Glasses.Add(glass);
    }

    public static void Delete(int id)
    {
        var Glass = Get(id);
        if(Glass is null)
            return;

        Glasses.Remove(Glass);
    }

    public static void Update(Glass glass)
    {
        var index = Glasses.FindIndex(p => p.Id == glass.Id);
        if(index == -1)
            return;

        Glasses[index] = glass;
    }
}