/**
 * Autogenerated by Thrift Compiler (0.9.2)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace DashcamNet.Thrift
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class MetricEvent : TBase
  {
    private long _sequenceNo;
    private string _route;

    public long CreatedTime { get; set; }

    public string Name { get; set; }

    public string Value { get; set; }

    /// <summary>
    /// 
    /// <seealso cref="MetricValueType"/>
    /// </summary>
    public MetricValueType ValueType { get; set; }

    public THashSet<string> Tags { get; set; }

    public long SequenceNo
    {
      get
      {
        return _sequenceNo;
      }
      set
      {
        __isset.sequenceNo = true;
        this._sequenceNo = value;
      }
    }

    public string Route
    {
      get
      {
        return _route;
      }
      set
      {
        __isset.route = true;
        this._route = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool sequenceNo;
      public bool route;
    }

    public MetricEvent() {
    }

    public MetricEvent(long createdTime, string name, string value, MetricValueType valueType, THashSet<string> tags) : this() {
      this.CreatedTime = createdTime;
      this.Name = name;
      this.Value = value;
      this.ValueType = valueType;
      this.Tags = tags;
    }

    public void Read (TProtocol iprot)
    {
      bool isset_createdTime = false;
      bool isset_name = false;
      bool isset_value = false;
      bool isset_valueType = false;
      bool isset_tags = false;
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.I64) {
              CreatedTime = iprot.ReadI64();
              isset_createdTime = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              Name = iprot.ReadString();
              isset_name = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.String) {
              Value = iprot.ReadString();
              isset_value = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.I32) {
              ValueType = (MetricValueType)iprot.ReadI32();
              isset_valueType = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.Set) {
              {
                Tags = new THashSet<string>();
                TSet _set14 = iprot.ReadSetBegin();
                for( int _i15 = 0; _i15 < _set14.Count; ++_i15)
                {
                  string _elem16;
                  _elem16 = iprot.ReadString();
                  Tags.Add(_elem16);
                }
                iprot.ReadSetEnd();
              }
              isset_tags = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.I64) {
              SequenceNo = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.String) {
              Route = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
      if (!isset_createdTime)
        throw new TProtocolException(TProtocolException.INVALID_DATA);
      if (!isset_name)
        throw new TProtocolException(TProtocolException.INVALID_DATA);
      if (!isset_value)
        throw new TProtocolException(TProtocolException.INVALID_DATA);
      if (!isset_valueType)
        throw new TProtocolException(TProtocolException.INVALID_DATA);
      if (!isset_tags)
        throw new TProtocolException(TProtocolException.INVALID_DATA);
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("MetricEvent");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      field.Name = "createdTime";
      field.Type = TType.I64;
      field.ID = 1;
      oprot.WriteFieldBegin(field);
      oprot.WriteI64(CreatedTime);
      oprot.WriteFieldEnd();
      field.Name = "name";
      field.Type = TType.String;
      field.ID = 2;
      oprot.WriteFieldBegin(field);
      oprot.WriteString(Name);
      oprot.WriteFieldEnd();
      field.Name = "value";
      field.Type = TType.String;
      field.ID = 3;
      oprot.WriteFieldBegin(field);
      oprot.WriteString(Value);
      oprot.WriteFieldEnd();
      field.Name = "valueType";
      field.Type = TType.I32;
      field.ID = 4;
      oprot.WriteFieldBegin(field);
      oprot.WriteI32((int)ValueType);
      oprot.WriteFieldEnd();
      field.Name = "tags";
      field.Type = TType.Set;
      field.ID = 5;
      oprot.WriteFieldBegin(field);
      {
        oprot.WriteSetBegin(new TSet(TType.String, Tags.Count));
        foreach (string _iter17 in Tags)
        {
          oprot.WriteString(_iter17);
        }
        oprot.WriteSetEnd();
      }
      oprot.WriteFieldEnd();
      if (__isset.sequenceNo) {
        field.Name = "sequenceNo";
        field.Type = TType.I64;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(SequenceNo);
        oprot.WriteFieldEnd();
      }
      if (Route != null && __isset.route) {
        field.Name = "route";
        field.Type = TType.String;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Route);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("MetricEvent(");
      __sb.Append(", CreatedTime: ");
      __sb.Append(CreatedTime);
      __sb.Append(", Name: ");
      __sb.Append(Name);
      __sb.Append(", Value: ");
      __sb.Append(Value);
      __sb.Append(", ValueType: ");
      __sb.Append(ValueType);
      __sb.Append(", Tags: ");
      __sb.Append(Tags);
      if (__isset.sequenceNo) {
        __sb.Append(", SequenceNo: ");
        __sb.Append(SequenceNo);
      }
      if (Route != null && __isset.route) {
        __sb.Append(", Route: ");
        __sb.Append(Route);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}