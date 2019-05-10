# dotnet-challenge

Get: /api/comments

Parameter: pageNumber (optional), pageSize (optional)

Response: 

		Code:					Description
		
		200					  Success
		
							[{commentId:1,
							  commentBody:''
							 userId: 1
							 commentDate:'2019-05-09'
							 blogTopicId:1
							user:{
								userId: 1,
								userName: 'Name',
								email: 'example@example.com'
								}
							blogTopic: { 
								id: 1,
								title: 'title',
								contents: 'contents',
								publishDateTime: '2019-05-09 11:20:00'}
							}]

Post: /api/comments

Parameter: 

		Name							Description


		comment							Example value

									{
										CommentBody: '',
										UserId: 1,
										BlogTopicId: 1
									}

Response

                Code						Descriptoin

                200							 Success



#todo
1. Format API document using swagger
2. Caching to prevent database read operation
3. Add SqlDependency to get the latest data and save into cache
								}
