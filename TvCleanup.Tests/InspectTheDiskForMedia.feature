Feature: Inspect the disk for media
	
	Media on disk should be identified per episode of a show. Per episode there might be multiple media files present

Scenario: One media file
	Given a file system
	| Filename                                          |
	| c:\media\tv\Show\S01E01\Show.S01E01.720p.HDTV.mkv |
	When I look for media in c:\media\tv
	Then 1 media file for show Show and episode S01E01 should be found
