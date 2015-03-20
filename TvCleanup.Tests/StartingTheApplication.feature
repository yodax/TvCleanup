Feature: Starting the application

	When the user start the application, it should display some information about it self

Scenario: User invokes the application
	Given an application
	When I start the application
	Then on the screen I should see
	"""
	Tv clean up
	"""
