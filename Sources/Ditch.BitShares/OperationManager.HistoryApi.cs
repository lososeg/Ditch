﻿using Ditch.Core.JsonRpc;
using Ditch.BitShares.Models;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.Models;

namespace Ditch.BitShares
{
    /**
     * @brief The history_api class implements the RPC API for account history
     *
     * This API contains methods to access account histories
     */

    /// <summary>
    /// history_api
    /// libraries\app\include\graphene\app\api.hpp
    /// </summary>
    public partial class OperationManager
    {
        /// <summary>
        /// API name: get_account_history
        ///  Get operations relevant to the specificed account
        /// 
        /// </summary>
        /// <param name="account">The account whose history should be queried (account_id_type)</param>
        /// <param name="stop">ID of the earliest operation to retrieve (operation_history_id_type)</param>
        /// <param name="limit">Maximum number of operations to retrieve (must not exceed 100)</param>
        /// <param name="start">ID of the most recent operation to retrieve</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>A list of operations performed by account, ordered from most recent to oldest.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<OperationHistoryObject[]>> GetAccountHistoryAsync(AccountIdType account, object stop, uint limit, object start, CancellationToken token)
        {
            return CustomGetRequestAsync<OperationHistoryObject[]>(KnownApiNames.HistoryApi, "get_account_history", new[] { account, stop, limit, start }, token);
        }

        /// <summary>
        /// API name: get_account_history_by_operations
        /// Get operations relevant to the specified account filtering by operation type
        ///
        /// 
        /// </summary>
        /// <param name="account">API type: account_id_type The account whose history should be queried</param>
        /// <param name="operationTypes">API type: vector&lt;uint16_t> The IDs of the operation we want to get operations in the account( 0 = transfer , 1 = limit order create, ...)</param>
        /// <param name="start">API type: uint32_t the sequence number where to start looping back throw the history</param>
        /// <param name="limit">API type: unsigned the max number of entries to return (from start number)</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: history_operation_detail history_operation_detail</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<HistoryOperationDetail>> GetAccountHistoryByOperationsAsync(AccountIdType account, ushort[] operationTypes, uint start, uint limit, CancellationToken token)
        {
            return CustomGetRequestAsync<HistoryOperationDetail>(KnownApiNames.HistoryApi, "get_account_history_by_operations", new object[] { account, operationTypes, start, limit }, token);
        }

        /// <summary>
        /// API name: get_relative_account_history
        /// 
        /// </summary>
        /// <param name="account">API type: account_id_type The account whose history should be queried</param>
        /// <param name="stop">API type: uint32_t Sequence number of earliest operation. 0 is default and will
        /// query 'limit' number of operations.</param>
        /// <param name="limit">API type: unsigned Maximum number of operations to retrieve (must not exceed 100)</param>
        /// <param name="start">API type: uint32_t Sequence number of the most recent operation to retrieve.
        /// 0 is default, which will start querying from the most recent operation.</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: operation_history_object A list of operations performed by account, ordered from most recent to oldest.</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<OperationHistoryObject[]>> GetRelativeAccountHistoryAsync(AccountIdType account, uint stop, uint limit, uint start, CancellationToken token)
        {
            return CustomGetRequestAsync<OperationHistoryObject[]>(KnownApiNames.HistoryApi, "get_relative_account_history", new object[] { account, stop, limit, start }, token);
        }

        /// <summary>
        /// API name: get_fill_order_history
        /// 
        /// </summary>
        /// <param name="a">API type: asset_id_type</param>
        /// <param name="b">API type: asset_id_type</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: order_history_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<OrderHistoryObject[]>> GetFillOrderHistoryAsync(AssetIdType a, AssetIdType b, uint limit, CancellationToken token)
        {
            return CustomGetRequestAsync<OrderHistoryObject[]>(KnownApiNames.HistoryApi, "get_fill_order_history", new object[] { a, b, limit }, token);
        }

        /// <summary>
        /// API name: get_market_history
        /// 
        /// </summary>
        /// <param name="a">API type: asset_id_type</param>
        /// <param name="b">API type: asset_id_type</param>
        /// <param name="bucketSeconds">API type: uint32_t</param>
        /// <param name="start">API type: fc::time_point_sec</param>
        /// <param name="end">API type: fc::time_point_sec</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: bucket_object</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<BucketObject[]>> GetMarketHistoryAsync(AssetIdType a, AssetIdType b, uint bucketSeconds, TimePointSec start, TimePointSec end, CancellationToken token)
        {
            return CustomGetRequestAsync<BucketObject[]>(KnownApiNames.HistoryApi, "get_market_history", new object[] { a, b, bucketSeconds, start, end }, token);
        }

        /// <summary>
        /// API name: get_market_history_buckets
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: flat_set</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<uint[]>> GetMarketHistoryBucketsAsync(CancellationToken token)
        {
            return CustomGetRequestAsync<uint[]>(KnownApiNames.HistoryApi, "get_market_history_buckets", token);
        }
    }
}
