# SnapsoftChallenge Scaffolding

This is an implementation of the "integration" part of SnapSoft's [SnapChallenge](https://challenge.snapsoft.hu/). It includes the framework to retrieve test cases and submit results, as well as a project for each challenge with the model classes for the Input and Output data already implemented. 

## How to use

First, set the QPA_TOKEN environment variable on a user or system level to the API token copied from the [Api Guide](https://challenge.snapsoft.hu/api-guide). Then implement any of the algorithms and play around with different run configurations:

* Sample0 and Sample1 run the algorithm against the first and second sample dataset respectively. Not all challenges have a second dataset.
* Live will run the algorithm against the real dataset. Number of submissions is limited, and each real dataset will run multiple test cases.
* Failed will run the algorithm against the last dataset for which a test run has failed.

See the source code of the Runner class for more details.

