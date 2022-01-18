using System.Collections.Generic;

namespace GlobalWarmingModel.Servies
{
    public interface IFileReader
    {
        double GetArcticSeaIce(int year);
        int GetDiameter(string countryname);
        double GetGlobalCO2(int year, char type);
        double GetGlobalTemp(int year);
        double GetIceSheets(int year);
        List<int> GetNationalCO2(string nation);
        double GetSeaLevel(int year, char type);
        double GetSeaLevelStandardDeviation(int year);
        int GetXCoordinate(string countryname);
        int GetYCoordinate(string countryname);
    }
}