using OnlineTrainTicketBookingApp.DAL;
using OnlineTrainTicketBookingApp.Entity;
using OnlineTrainTicketBookingMVC;
using System.Collections.Generic;

namespace OnlineTrainTicketBookingApp.BL
{
    public interface ITrainClassBL          //Interface for Train class BL
    {
        List<TrainClassDetails> GetTrainClass(int trainId);
        List<TrainClass> GetTrainClassList();
        void AddTrainClass(TrainClassDetails trainClassDetails);
        TrainClassDetails GetClass(int id);
        void EditTrainClass(TrainClassDetails trainClassDetails);
        void DeleteTrainClass(TrainClassDetails trainClassDetails);
        bool AddClass(TrainClass trainClass);
    }
    public class TrainClassBL : ITrainClassBL       //Implementing interface in TrainClass BL class
    {
        ITrainClassRepository trainClassRepository;
        public TrainClassBL()
        {
            trainClassRepository = new TrainClassRepository();      //An object to communicate with dal
        }

        public List<TrainClassDetails> GetTrainClass(int trainId)
        {
            return trainClassRepository.GetTrainClass(trainId);
        }
        public List<TrainClass> GetTrainClassList()             //Method to get class details
        {
            return trainClassRepository.GetTrainClassList();
        }
        public void AddTrainClass(TrainClassDetails trainClassDetails)
        {
            trainClassRepository.AddTrainClass(trainClassDetails);
        }
        public TrainClassDetails GetClass(int id)               //Method to get particular class by id
        {
            return trainClassRepository.GetClass(id);
        }
        public void EditTrainClass(TrainClassDetails trainClassDetails) // Method to edit and delete details based on ID
        {
            trainClassRepository.EditTrainClass(trainClassDetails);
        }
        public void DeleteTrainClass(TrainClassDetails trainClassDetails)   //Method to delete train class details
        {
            trainClassRepository.DeleteTrainClass(trainClassDetails);
        }
        public bool AddClass(TrainClass trainClass)             //Method to add train classes in db
        {
            return trainClassRepository.AddClass(trainClass);
        }

    }
}
