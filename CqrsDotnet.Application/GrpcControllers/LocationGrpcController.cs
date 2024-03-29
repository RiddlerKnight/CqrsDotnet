using CqrsDotnet.Infrastructure.ProtosModels;
using Grpc.Core;
using Serilog;

namespace CqrsDotnet.Application.GrpcControllers;


public class LocationGrpcController : LocationGrpc.LocationGrpcBase
{
    public override Task<LocationReply> SyncLocation(LocationRequest request, ServerCallContext context)
    {
        Log.Information("Location | lat: {Lat} | long: {Long}", request.Lat, request.Long);
        return Task.FromResult(new LocationReply() { Lat = "18.0101010", Long = "100.0101010"});
    }
}