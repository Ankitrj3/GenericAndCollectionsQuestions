public class RobotSafetyException : Exception
{
    public RobotSafetyException(string message) : base(message)
    {
        
    }
}
public class RobotHazardAuditor
{
    public double ArmPrecision{get;set;}
    public int WorkerDensity{get;set;}
    public string? MachineryState{get;set;}
    public RobotHazardAuditor(){}
    public RobotHazardAuditor(double armPrecision, int workerDensity, string machineryState)
    {
        ArmPrecision = armPrecision;
        WorkerDensity = workerDensity;
        MachineryState = machineryState;
    }
    public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
    {
        if(armPrecision < 0.0 || armPrecision > 1.0)
        {
            throw new RobotSafetyException("Error:  Arm precision must be 0.0-1.0");
        }
        if(workerDensity < 1 || workerDensity > 20)
        {
            throw new RobotSafetyException("Error: Worker density must be 1-20");
        }
        if(machineryState != "Worn" && machineryState != "Faulty" && machineryState != "Critical")
        {
            throw new RobotSafetyException("Error: Unsupported machinery state");
        }

        double machineRiskFactor = 0;
        if(machineryState == "Worn")
        {
            machineRiskFactor = 1.3;
        }else if(machineryState == "Faulty")
        {
            machineRiskFactor = 2.0;
        }
        else
        {
            machineRiskFactor = 3.0;
        }
        double HazardRisk = ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor);
        return HazardRisk;

    }
}
public class Program
{
    public static void Main()
    {
        
    }
}