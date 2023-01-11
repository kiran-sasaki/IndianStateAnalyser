using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DataDAO;

namespace CensusAnalyserTest
{
    [TestClass]
    public class IndianCensusTestClass
    {
        string stateCodePath = @"E:\C#\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Census\StateCode.csv";
        string stateCensusPath = @"E:\C#\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Census\StateCensusData.csv";
        string wrongCensusPath = @"E:\C#\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Cens\StateCensusData.csv";
        string wrongStateCodePath = @"E:\C#\IndianStateCensusAnalyser\IndianStateCensusAnalr\Census\StateCode.csv";
        string wrongTypeStateCodePath = @"E:\C#\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Census\StateCode.txt";
        string wrongHeaderStateCodePath = @"E:\C#\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Census\WorngStateCode.csv";
        string wrongHeaderStateCensusPath = @"E:\C#\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Census\WorngStateCensusData.csv";
        string delimiterStateCodePath = @"E:\C#\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Census\DelimiterStateCode.csv";
        string delimiterStateCensusPath = @"E:\C#\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Census\DelemiterStateCensusData.csv";

        public CSVAdapterFactory csv;
        public Dictionary<string, CensusDataDAO> stateRecords;
        public Dictionary<string, StateCodeDataDao> totalRecords;

        [TestInitialize]
        public void SetUp()
        {
            csv = new CSVAdapterFactory();
            totalRecords = new Dictionary<string, StateCodeDataDao>();
            stateRecords = new Dictionary<string, CensusDataDAO>();
        }
        /// TC 1.1
        /// Giving the correct path it should return the total count from the census
        [TestMethod]
        public void GivenStateCensusCSVFileShouldReturnRecords()
        {
            stateRecords = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, stateRecords.Count);
        }
        /// TC 1.2
        /// Giving incorrect path should return File Not Found custom exception
        [TestMethod]
        public void GivenIncorrectFileShouldThrowCustomException()
        {
            try
            {
                var customException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
                //total no of rows excluding header are 29 in indian state census data.
                //Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customException.exception);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
        }
        /// TC 1.3
        /// Giving wrong type of path should return Invalid file type custom exception
        [TestMethod]
        public void GivenWrongTypeReturnsCustomException()
        {
            try
            {
                var customException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeStateCodePath, "SrNo,State Name,TIN,StateCode"));
                Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// TC 1.4
        /// Giving wrong delimiter should return incorrect delimiter custom exception
        [TestMethod]
        public void GivenWrongDelimeterReturnsCustomException()
        {
            try
            {
                var censusException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, delimiterStateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
                Assert.AreEqual(censusException.exception, CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// TC 1.5
        /// Giving wrong header type should return incorrect header type custom exception
        [TestMethod]
        public void GivenWrongHeaderReturnsCustomException()
        {
            try
            {
                var censusException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
                Assert.AreEqual(censusException.exception, CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}