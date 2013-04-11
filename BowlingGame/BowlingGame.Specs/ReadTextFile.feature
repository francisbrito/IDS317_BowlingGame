Feature: Read a text file
	In order to know the scores from bowling games
	As a bowling game app user
	I want to be able to read text files

@base_case
Scenario: Read a text file from local file system
	Given I want to load a file called "scores.txt"
	And its on my local file system
	When I press load
	Then the app should load the file

@exception
Scenario: Read a text file that doesnt exists on local file system
	Given I want to load a file called "unexistent.txt"
	But its not on my local file system
	When I press load
	Then the app should notify me the file doesnt exists

@exception
Scenario: Read a text file that I dont have access to from local file system
	Given I want to load a file called "prohibited.txt"
	And its on my local file system
	But I dont have permissions to access it
	When I press load
	Then the app should notify me the file cant be accessed

@base_case
Scenario: Read a text file from a network share
	Given I want to load a file called "net_scores.txt"
	And its on a network share
	When I press load
	Then the app should load the file

@exception
Scenario: Read a text file that I dont have access to from a network share
	Given I want to load a file called "net_prohibited.txt"
	And its on a network share
	But I dont have permissions to access it
	When I press load
	Then the app should notify me the file cant be accessed

@base_case
Scenario: Read a text file from the internet
	Given I want to load a file called "inet_scores.txt"
	And its on a internet server called "http://localhost/"
	When I press load
	Then the app should load the file

@exception
Scenario: Read a text file that doesnt exists on the internet
	Given I want to load a file called "404.txt"
	But its not on the internet
	When I press load
	Then the app should notify me the file doesnt exists

@exception
Scenario: Read a text file that I dont have access to from internet
	Given I want to load a file called "403.txt"
	And its on a internet server called "http://localhost/"
	But I dont have permissions to access it
	When I press load
	Then the app should notify me the file cant be accessed