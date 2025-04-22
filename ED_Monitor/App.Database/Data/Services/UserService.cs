using System.Security.Cryptography;

namespace App.Database.Data.Services;

public class UserService
{
	// Define how many times the PBKDF2  - passowrd based key derivation function 2 -
	// algorithm should be applied to the pw given
	// This is to make it easier to make the system stromger by alterring 
	// the number of iterations from a variable 
	const int Iterations = 50000; 
	// Storing the algorithm used in a variable to make it easier to change in the future if necessary
	static HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA512;
    public string SaltyPassword(string password)
    {
		// Function to safely store salted hash passwords
  		// Using PVBKDF2 and SHA256

		// Genrate a random salt to the start of the pw to make it unique before hashing
		// Stored in an array for easier manipulation and retrival
        byte[] salt = RandomNumberGenerator.GetBytes(16); 
		// Implememnt pbkdf2 algortithm 
        var alg = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithm);
		// Get hashed representation of the password
        byte[] hash = alg.GetBytes(32);

        // Combine salt and hash and save in hashBytes array 
        byte[] hashBytes = new byte[salt.Length + hash.Length];
        Array.Copy(salt, 0, hashBytes, 0, salt.Length);
        Array.Copy(hash, 0, hashBytes, salt.Length, hash.Length);

        // Convert to base 64 for storage
        return Convert.ToBase64String(hashBytes);
    }

    // Method to verify password by comparing the input hashed version 
	// with the stored version - both hashed with the same salt 
    public bool VerifyPassword(string password, string storedHash)
    {
        // Decode the stored hash
        byte[] hashBytes = Convert.FromBase64String(storedHash);

        // Extract the salt in the first 16 bytes
        byte[] salt = new byte[16];
        Array.Copy(hashBytes, 0, salt, 0, salt.Length);

        // Extract the hash from the remaining bytes
        byte[] storedPasswordHash = new byte[hashBytes.Length - salt.Length];
        Array.Copy(hashBytes, salt.Length, storedPasswordHash, 0, storedPasswordHash.Length);

        // Hash the input password with the same salt
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithm);
        byte[] inputPasswordHash = pbkdf2.GetBytes(32);

        // Compare the hashes
        return inputPasswordHash.SequenceEqual(storedPasswordHash);
    }
}