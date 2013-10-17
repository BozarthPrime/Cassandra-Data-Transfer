Cassandra Data Transfer
=======================
Author: Joseph Bozarth,
Date Created: 10-16-2013

Description
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


License
-------
Copyright 2013, TRICAST, inc.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
