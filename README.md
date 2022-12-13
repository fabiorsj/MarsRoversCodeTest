# run
dotnet run --project MarsRovers

# test
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./lcov.info MarsRovers.Tests
