using System;
namespace OnlineTrainTicketBooking
{
    public class Train
    {
        public int trainNo { get; set; }        //Properties of Train
        public string trainName { get; set; }
        public string sourceStation { get; set;}
        public string destinationStation { get; set;}
        public DateTime departTime { get; set; }
        public DateTime arrivalTime { get; set; }        
        public int trainKM { get; set; }
        public int totalSeats { get; set; }
        public int fare { get; set;}  
        public Train(int trainNo, string trainName, string sourceStation, string destinationStation, DateTime departTime, DateTime arrivalTime, int trainKM, int totalSeats, int fare)
        {
            this.trainNo = trainNo;                     //Using parameterized constructor to bind data in objects
            this.trainName = trainName;
            this.sourceStation = sourceStation;
            this.destinationStation = destinationStation;
            this.departTime = departTime;
            this.arrivalTime = arrivalTime;
            this.trainKM = trainKM;
            this.totalSeats = totalSeats;
            this.fare = fare;            
        }          
    }
}
