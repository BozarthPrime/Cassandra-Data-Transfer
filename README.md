Cassandra Data Transfer
=======================
Author: Joseph Bozarth,
Date Created: 10-16-2013

Overview
---------------------------

This application is meant to facilitate the movement of data from one instance
of Cassandra to another, say from development to QA or production, and/or from one
column family to another, say you have a backup table or something of the kin.

I am making use of the C# Cassandra API from Datastax but it is a modified version.
I have added support for the retrival and insertion of dynamics and dictionaries as
well as fixed an issue with connecting to multiple databases that currently exsists
in the master branch of the project. My source code for that can be found on my
GitHub page here https://github.com/BozarthPrime/csharp-driver.


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
