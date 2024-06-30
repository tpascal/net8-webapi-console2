# Weather Observation API
A system that can retrieve South Australian weather observation data from the Bureau of Meteorology.

## Overview
This API provides access to weather observation data from various stations within the Adelaide Area. It allows users to retrieve comprehensive data sets or specific data points like temperature, apparent temperature, and dew point in JSON format.

## Features
- **Retrieve All Data**: Fetch all available weather observation data for a selected station.
- **IIS Deployable**: Ready to be deployed on an Internet Information Services (IIS) web server.

## Getting Started
To use this API, you'll need to set it up on an IIS web server. Follow the instructions below to get started.

### Prerequisites
- IIS web server
- .NET 8 Core runtime

### Installation
1. Clone the repository to your server.
2. Configure IIS to point to the deployed service, it needs to be hosted at https://localhost:7224
2. Navigate to ConsoleApp folder and use the `dotnet` CLI to build and run the console application.


## Usage
The API endpoints is as follows:

### Retrieve Weather Observation Data For Station
GET /api/weatherstation/{stationId}

Retrieves weather observation data for the specified station and returns the average temperature

Deployment
For deployment on IIS, please refer to the official IIS documentation for detailed instructions.

