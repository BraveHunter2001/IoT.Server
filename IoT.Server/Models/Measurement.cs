namespace IoT.Server.Models;

public class Measurement
{
    public int aX { get; set; }
    public int aY { get; set; }
    public int aZ { get; set; }

    public double tmp { get; set; }

    public int gX { get; set; }
    public int gY { get; set; }
    public int gZ { get; set; }

    public override string ToString()
    {
        return $"aX:{aX} aY:{aY} aZ:{aZ}| tmp:{tmp}| gX:{gX}  gY:{gY}  gZ:{gZ}";
    }
}
