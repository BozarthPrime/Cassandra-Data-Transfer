Cassandra Data Transfer
=======================
Author: Joseph Bozarth,
Date Created: 10-16-2013

---------------------------

This application makes use of the Datastax C# Appache Cassandra API
and is meant to be used to transfer data between cassandra instances and tables.
For example one might need to move data between a development and a production
enviroment or you might want to move data within the same instance of cassandra
between two key spaces one of which is a development version and the other a
production version.
  
The version of the Datastax api that is being used is a modified version. The current
main branch does not support connecting to multiple databases but this was a simple
fix that I implemented in a branch of the github. This source code can be found
here: https://github.com/BozarthPrime/csharp-driver
