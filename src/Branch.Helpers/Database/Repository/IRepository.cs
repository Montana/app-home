using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Branch.Helpers.Database.Repository
{
	public interface IRepository<T>
	{
		/// <summary>
		/// Gets all items of type <see cref="T"/> in the repository.
		/// </summary>
		/// <param name="startAt">Starting index in the repository to retrieve items from.</param>
		/// <param name="count">How many items to retieve from the repository.</param>
		/// <returns>All the items within the specified <see cref="startAt"/> and <see cref="count"/>.</returns>
		Task<IEnumerable<T>> GetAllAsync(int startAt = 0, int count = int.MaxValue);

		/// <summary>
		/// Returns all items that match the given predicate in the repository.
		/// </summary>
		/// <param name="predicate">The expression returned items must satisfy.</param>
		/// <returns>All the items in the repository that satisfy the given expression.</returns>
		IEnumerable<T> Where(Expression<Func<T, bool>> predicate);

		/// <summary>
		/// Gets an item of type <see cref="T"/> from the repository based on it's Id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>The item from the database with the specified Id. Will be <see cref="null"/> if the item doens't exist.</returns>
		Task<T> GetByIdAsync(int id);

		/// <summary>
		/// Add an item of type <see cref="T"/> in the repository.
		/// </summary>
		/// <param name="item">The model to add to repository.</param>
		/// <returns>The model from the repository.</returns>
		Task<T> AddAsync(T item);

		/// <summary>
		/// Update an item of type <see cref="T"/> in the repository.
		/// </summary>
		/// <param name="delta">The model to update the repository from.</param>
		/// <returns>The updated model from the repository.</returns>
		Task<T> UpdateAsync(T delta);

		/// <summary>
		/// Delete an item of type <see cref="T"/> from the repository.
		/// </summary>
		/// <param name="id">The Id of the item to delete.</param>
		/// <returns>A <see cref="Boolean"/> representation of the deletion status.</returns>
		Task<bool> DeleteAsync(int id);
	}
}
