# Rabbit MQ Docker and C# Scalffolding Project Setup


Step1 : Make sure docker desktop is running in your machine, if not - run below command and ensure Rabbit MQ is in running state

```sh
docker run --rm -d --hostname my-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:3-management

-- After completion, check it is in running state
docker ps
```

## Step 2:  Browse Rabbit MQ console [http://localhost:15672/](http://localhost:15672/)
User Id: guest
Password: guest

## Step 3: Build producer microservice

```sh
dotnet new webapi -n microservice-producer
```

Open the solution in vs code and remove https://localhost:5000 from Properties\launchsettings.json

and comment app.UseHttpsRedirection(); in Startup.cs

dotnet run and browse - ensure setup is working

[http://localhost:5000/weatherforecast](http://localhost:5000/weatherforecast) 

### Send a new message
```sh
-- POST THE MESSAGE
curl --request POST 'http://localhost:5000/weatherforecast' \
--header 'Content-Type: application/json' \
--header 'Cookie: X-Correlation-ID=0HM20ISEJN8FN-00000002' \
--data-raw '{
"name": "Indian",
"country": "India",
"email": "india@email.com"
}'
```

## Step 4: Build consumer microservice

```sh
dotnet new webapi -n microservice-consumer
```

Open the solution in vs code and remove [https://localhost:5000](https://localhost:5000/) from Properties\launchsettings.json

and comment app.UseHttpsRedirection(); in Startup.cs

dotnet run and browse - ensure setup is working

http://localhost:7000

### See consumed  message
Check the log when you produce or put the breakpoint in handle method (MessageHandler.cs)
