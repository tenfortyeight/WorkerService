WorkerService
=============

Proof of concept to have a worker service pushing notifications via SignalR to a client GUI. The web apps are connected via SqlServer backplane, for use in a distributed scenario or fail over.


Worker
======
Illustrates a worker application, a windows service or similar for instance.


Subscriber
=========
Presents updates in the stream, represents a app showing user when something is done.


Communicator
============
Originally intended as the host for the Worker, through which the worker communicated. Now only a representation of a second app, subscribing to updates. 
