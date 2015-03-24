Feature: Inspect the disk for media
	
	Media on disk should be identified per episode of a show. Per episode there might be multiple media files present

Scenario: One media file
	Given a file system
	| Filename                                          |
	| c:\media\tv\Show\S01E01\Show.S01E01.720p.HDTV.mkv |
	When I look for media in c:\media\tv
	Then there should be 1 show called show
	And there should be 1 episode S01E01
	And there should be 1 media called Show.S01E01.720p.HDTV
	And there should be 1 file called c:\media\tv\Show\S01E01\Show.S01E01.720p.HDTV.mkv

Scenario: Two files for one media
	Given a file system
	| Filename                                          |
	| c:\media\tv\Show\S01E01\Show.S01E01.720p.HDTV.mkv |
	| c:\media\tv\Show\S01E01\Show.S01E01.720p.HDTV.srt |
	When I look for media in c:\media\tv
	Then there should be 1 show called show
	And there should be 1 episode S01E01
	And there should be 1 media called Show.S01E01.720p.HDTV
	And there should be 1 file called c:\media\tv\Show\S01E01\Show.S01E01.720p.HDTV.mkv
	And there should be 1 file called c:\media\tv\Show\S01E01\Show.S01E01.720p.HDTV.srt

Scenario: Two files for two medias
	Given a file system
	| Filename                                             |
	| c:\media\tv\Show\S01E01\Show.S01E01.720p.HDTV.mkv    |
	| c:\media\tv\Show\S01E01\Show.S01E01.720p.HDTV.srt    |
	| c:\media\tv\Show\S01E01\Show.S01E01.1080p.WEB-DL.mkv |
	| c:\media\tv\Show\S01E01\Show.S01E01.1080p.WEB-DL.srt |
	When I look for media in c:\media\tv
	Then there should be 1 show called show
	And there should be 1 episode S01E01
	And there should be 1 media called Show.S01E01.720p.HDTV
	And there should be 1 file called c:\media\tv\Show\S01E01\Show.S01E01.720p.HDTV.mkv
	And there should be 1 file called c:\media\tv\Show\S01E01\Show.S01E01.720p.HDTV.srt
	And there should be 1 media called Show.S01E01.1080p.WEB-DL
	And there should be 1 file called c:\media\tv\Show\S01E01\Show.S01E01.1080p.WEB-DL.mkv
	And there should be 1 file called c:\media\tv\Show\S01E01\Show.S01E01.1080p.WEB-DL.srt

Scenario: Two files for two medias for two shows with two episodes
	Given a file system
	| Filename                                               |
	| c:\media\tv\Show\S01E01\Show.S01E01.720p.HDTV.mkv      |
	| c:\media\tv\Show\S01E01\Show.S01E01.720p.HDTV.srt      |
	| c:\media\tv\Show\S01E01\Show.S01E01.1080p.WEB-DL.mkv   |
	| c:\media\tv\Show\S01E01\Show.S01E01.1080p.WEB-DL.srt   |
	| c:\media\tv\Show\S01E02\Show.S01E02.720p.HDTV.mkv      |
	| c:\media\tv\Show\S01E02\Show.S01E02.720p.HDTV.srt      |
	| c:\media\tv\Show\S01E02\Show.S01E02.1080p.WEB-DL.mkv   |
	| c:\media\tv\Show\S01E02\Show.S01E02.1080p.WEB-DL.srt   |
	| c:\media\tv\Show2\S01E01\Show2.S01E01.720p.HDTV.mkv    |
	| c:\media\tv\Show2\S01E01\Show2.S01E01.720p.HDTV.srt    |
	| c:\media\tv\Show2\S01E01\Show2.S01E01.1080p.WEB-DL.mkv |
	| c:\media\tv\Show2\S01E01\Show2.S01E01.1080p.WEB-DL.srt |
	| c:\media\tv\Show2\S01E02\Show2.S01E02.720p.HDTV.mkv    |
	| c:\media\tv\Show2\S01E02\Show2.S01E02.720p.HDTV.srt    |
	| c:\media\tv\Show2\S01E02\Show2.S01E02.1080p.WEB-DL.mkv |
	| c:\media\tv\Show2\S01E02\Show2.S01E02.1080p.WEB-DL.srt |
	When I look for media in c:\media\tv
	Then there should be 1 show called show
	And there should be 1 episode S01E01
	And there should be 1 media called Show.S01E01.720p.HDTV
	And there should be 1 file called c:\media\tv\Show\S01E01\Show.S01E01.720p.HDTV.mkv
	And there should be 1 file called c:\media\tv\Show\S01E01\Show.S01E01.720p.HDTV.srt
	And there should be 1 media called Show.S01E01.1080p.WEB-DL
	And there should be 1 file called c:\media\tv\Show\S01E01\Show.S01E01.1080p.WEB-DL.mkv
	And there should be 1 file called c:\media\tv\Show\S01E01\Show.S01E01.1080p.WEB-DL.srt
	And there should be 1 episode S01E02
	And there should be 1 media called Show.S01E02.720p.HDTV
	And there should be 1 file called c:\media\tv\Show\S01E02\Show.S01E02.720p.HDTV.mkv
	And there should be 1 file called c:\media\tv\Show\S01E02\Show.S01E02.720p.HDTV.srt
	And there should be 1 media called Show.S01E02.1080p.WEB-DL
	And there should be 1 file called c:\media\tv\Show\S01E02\Show.S01E02.1080p.WEB-DL.mkv
	And there should be 1 file called c:\media\tv\Show\S01E02\Show.S01E02.1080p.WEB-DL.srt
	And there should be 1 show called show2
	And there should be 1 episode S01E01
	And there should be 1 media called Show2.S01E01.720p.HDTV
	And there should be 1 file called c:\media\tv\Show2\S01E01\Show2.S01E01.720p.HDTV.mkv
	And there should be 1 file called c:\media\tv\Show2\S01E01\Show2.S01E01.720p.HDTV.srt
	And there should be 1 media called Show2.S01E01.1080p.WEB-DL
	And there should be 1 file called c:\media\tv\Show2\S01E01\Show2.S01E01.1080p.WEB-DL.mkv
	And there should be 1 file called c:\media\tv\Show2\S01E01\Show2.S01E01.1080p.WEB-DL.srt
	And there should be 1 episode S01E02
	And there should be 1 media called Show2.S01E02.720p.HDTV
	And there should be 1 file called c:\media\tv\Show2\S01E02\Show2.S01E02.720p.HDTV.mkv
	And there should be 1 file called c:\media\tv\Show2\S01E02\Show2.S01E02.720p.HDTV.srt
	And there should be 1 media called Show2.S01E02.1080p.WEB-DL
	And there should be 1 file called c:\media\tv\Show2\S01E02\Show2.S01E02.1080p.WEB-DL.mkv
	And there should be 1 file called c:\media\tv\Show2\S01E02\Show2.S01E02.1080p.WEB-DL.srt
