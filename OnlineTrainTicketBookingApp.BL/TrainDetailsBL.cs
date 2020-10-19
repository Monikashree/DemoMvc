using OnlineTrainTicketBookingApp.DAL;
using System.Collections.Generic;
using OnlineTrainTicketBookingApp.Entity;
using OnlineTrainTicketBookingMVC;

namespace OnlineTrainTicketBookingApp.BL
{
    public interface ITrainDetailsBL            //A Train details BL layer interface to highlight the things we do
    {
        IEnumerable<TrainDetails> GetTrainDetails();
        bool AddTrainDetails(TrainDetails trainDetails);
        TrainDetails GetTrainByNo(int trainNo);
        void UpdateTrainDetails(TrainDetails trainDetails);
        void DeleteTrainDetails(int trainNo);
        List<TrainDetails> SearchTrain(string source, string destination);
        List<TrainClassDetails> GetSeatDetailsById(int trainId);

    }
    public class TrainDetailsBL : ITrainDetailsBL   //Class implementing Interface of TrainDetails
    {
        ITrainDetailsRepository trainDetailsRepository;

        public TrainDetailsBL()                     //Communicating with DAL via bl to acces data from the database
        {
            trainDetailsRepository = new TrainDetailsRepository();
        }
        public IEnumerable<TrainDetails> GetTrainDetails()      //Method to get train detaild from the db
        {
            return trainDetailsRepository.GetTrainDetails();
        }
        public bool AddTrainDetails(TrainDetails trainDetails)      //Method to Add train details
        {
            return trainDetailsRepository.AddTrainDetails(trainDetails);
        }
        public TrainDetails GetTrainByNo(int trainNo)           //Method to get Train details based on train Id
        {
            return trainDetailsRepository.GetTrainByNo(trainNo);
        }

        public void UpdateTrainDetails(TrainDetails trainDetails)   //Method to update train details
        {
            trainDetailsRepository.UpdateTrainDetails(trainDetails);
        }
        public void DeleteTrainDetails(int trainNo)             //Method to delete train details by Id
        {
            trainDetailsRepository.DeleteTrainDetails(trainNo);
        }

        public List<TrainDetails> SearchTrain(string source, string destination)    //Method to search train based on source and destination
        {
            return trainDetailsRepository.SearchTrain(source, destination);
        }

        public List<TrainClassDetails> GetSeatDetailsById(int trainId)      //Method to get train details from the db
        {
            return trainDetailsRepository.GetSeatDetailsById(trainId);
        }

    }
}
