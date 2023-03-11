export DB_CONNECTION_STRING="host=postgres_image;port=5432;database=swdb;username=swuser;password=swuser"
export METADATA_PATH="/../../MetaData/"

dotnet run --project dotnet/SimpleWordMain
