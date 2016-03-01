namespace java com.dcf.iqunxing.fx.dashcam.common.models.thrift
namespace csharp DashcamNet.Thrift

enum LogLevel{
	DEBUG = 0,
	INFO = 1,
	WARN = 2,
	ERROR = 3,
	FATAL = 4
}

enum LogType{
	OTHER = 0,
	APP = 1,
	URL = 2,
	WEB_SERVICE = 3,
	SQL = 4,
	MEMCACHED = 5
}

enum SpanType{
	OTHER = 0,
	URL = 1,
	WEB_SERVICE = 2,
	SQL = 3,
	MEMCACHED = 4
}

enum MetricValueType{
	TYPE_FLOAT = 0,
	TYPE_LONG = 1
}

enum ResultCode{
	SUCCESS = 0,
	FAILURE = 1,
	TRY_LATER = 2
}

struct LogEvent{
	1: required i64 id = -1,
	2: required LogType logType,
	3: optional i64 createdTime,
	4: optional i64 threadId,
	5: optional i64 traceId,
	6: optional LogLevel logLevel,
	7: optional map<string, string> attributes,
	8: optional string title,
	9: optional string message,
	10: optional string source,
	11: optional i64 sequenceNo,
	12: optional string route,
	13: optional i64 spanId
}

struct Span{
	1: required string name,
	2: required string serviceName,
	3: required string hostIp,
	4: required SpanType spanType,
	5: required i64 traceId,
	6: required i64 spanId,
	7: required i64 parentId,
	8: required i64 startTime,
	9: required i64 stopTime,
	10: required list<LogEvent> logEvents,
	11: required bool unfinished,
	12: required i64 threadId,
	13: optional i64 sequenceNo,
	14: optional string route,
	15: optional map<string, string> attributes,
	16: optional string appId,
	17: optional string hostName,
	18: optional i64 processId
}

struct MetricEvent{
	1: required i64 createdTime,
	2: required string name,
	3: required string value,
	4: required MetricValueType valueType,
	5: required set<string> tags,
	6: optional i64 sequenceNo,
	7: optional string route
}

struct Event{
	1: required string nameSpace,
	2: required string name,
	3: required i64 time,
	4: required map<string, string> attributes,
	6: optional i64 sequenceNo,
	7: optional string route
}

struct Chunk{
	1: required string hostIp,
	2: required string hostName,
	3: required i32 appId,
	4: optional i64 processId,
	5: required list<LogEvent> logEvents,
	6: required list<Span> spans,
	7: required list<MetricEvent> metrics,
	8: required list<Event> events,
	9: optional i64 sequenceNo,
	10: optional string route,
	11: required string env,
	12: required string envGroup
}

struct Result{
	1: required ResultCode resultCode
}