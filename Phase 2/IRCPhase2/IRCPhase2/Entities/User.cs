namespace IRCPhase2.Entities
{
    /// <summary>
    /// User Class, Carries the data concerning the User
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the UserName of this User
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the Unique Nickname for this User
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Check for Equality condition for between this User and another obj
        /// </summary>
        /// <param name="obj">The User to Check Equality with</param>
        /// <returns>Equality Result</returns>
        public override bool Equals(object obj)
        {
            User otherUser = (User)obj;
            if (this.Nickname != null && otherUser.Nickname != null)
            {
                return this.Nickname.ToLower().Equals(otherUser.Nickname.ToLower());
            }

            return false;
        }
    }
}