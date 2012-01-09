namespace IRCPhase2.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// LSAType Enum
    /// </summary>
    public enum LSAType
    {
        /// <summary>
        /// Advertisement Type
        /// </summary>
        Advertisement = 0,

        /// <summary>
        /// Acknowledgement Type
        /// </summary>
        Acknowledgement = 1
    }

    /// <summary>
    /// LSA Class, that Carries the data concerning the LSA
    /// </summary>
    public class LSA : ICloneable
    {
        /// <summary>
        /// Initializes a new instance of the LSA class.
        /// </summary>
        public LSA()
        {
            this.Users = new List<User>();
            this.Links = new List<Node>();
        }

        /// <summary>
        /// Gets or sets the LSA's Version
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Gets or sets the LSA's Type
        /// </summary>
        public LSAType Type { get; set; }

        /// <summary>
        /// Gets or sets the LSA's Time To Live
        /// </summary>
        public int TTL { get; set; }

        /// <summary>
        /// Gets or sets the LSA's Version
        /// </summary>
        public int SenderNodeID { get; set; }

        /// <summary>
        /// Gets or sets the LSA's Sequence Number
        /// </summary>
        public int SequenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the LSA's Neighbours
        /// </summary>
        public List<Node> Links { get; set; }

        /// <summary>
        /// Gets or sets the LSA's Users
        /// </summary>
        public List<User> Users { get; set; }

        /// <summary>
        /// Creates a Shallow Copy for this Object
        /// </summary>
        /// <returns>Shallow Copy of this LSA Object</returns>
        public object Clone()
        {
            User[] tmpUserArr;
            Node[] tmpNodeArr;

            LSA obj = new LSA();
            obj.Version = this.Version;
            obj.Type = this.Type;
            obj.TTL = this.TTL;
            obj.SenderNodeID = this.SenderNodeID;
            obj.SequenceNumber = this.SequenceNumber;

            tmpUserArr = new User[this.Users.Count];
            this.Users.CopyTo(tmpUserArr);
            obj.Users = tmpUserArr.ToList();

            tmpNodeArr = new Node[this.Links.Count];
            this.Links.CopyTo(tmpNodeArr);
            obj.Links = tmpNodeArr.ToList();

            return obj;
        }
    }
}