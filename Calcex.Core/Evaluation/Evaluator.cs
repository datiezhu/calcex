﻿using Calcex.Parsing.Tokens;

namespace Calcex.Evaluation
{
    /// <summary>
    /// The base class for all evaluators.
    /// </summary>
    public abstract class Evaluator<T>
    {
        protected Parser parser;

        public EvaluationContext Context { get; }

        public Evaluator(Parser parser, EvaluationContext context)
        {
            this.parser = parser;
            this.Context = context;
        }

        /// <summary>
        /// Evaluates a given operator token.
        /// </summary>
        /// <param name="token">The token to be evaluated.</param>
        /// <returns>The evaluated value.</returns>
        public abstract T EvaluateOperator(OperatorToken token);

        /// <summary>
        /// Evaluates a given function token.
        /// </summary>
        /// <param name="token">The token to be evaluated.</param>
        /// <returns>The evaluated value.</returns>
        public abstract T EvaluateFunction(FuncToken token);

        /// <summary>
        /// Evaluates a given iteration function token.
        /// </summary>
        /// <param name="token">The token to be evaluated.</param>
        /// <returns>The evaluated value.</returns>
        public abstract T EvaluateVarFunction(VarFuncToken token);

        /// <summary>
        /// Evaluates a given number token.
        /// </summary>
        /// <param name="token">The token to be evaluated.</param>
        /// <returns>The evaluated value.</returns>
        public abstract T EvaluateNumber(NumberToken token);

        /// <summary>
        /// Evaluates a given variable token.
        /// </summary>
        /// <param name="token">The token to be evaluated.</param>
        /// <returns>The evaluated value.</returns>
        public abstract T EvaluateVar(VarToken token);

        /// <summary>
        /// Evaluates a given constant token.
        /// </summary>
        /// <param name="token">The token to be evaluated.</param>
        /// <returns>The evaluated value.</returns>
        public abstract T EvaluateConstant(ConstantToken token);

        /// <summary>
        /// Evaluates an array of given tokens.
        /// </summary>
        /// <param name="tokens">An array of tokens to be evaluated.</param>
        /// <returns>An array containing the evaluated value for each given token.</returns>
        public T[] EvaluateTokens(TreeToken[] tokens)
        {
            T[] results = new T[tokens.Length];
            for (int i = 0; i < tokens.Length; i++)
            {
                results[i] = tokens[i].Evaluate(this);
            }
            return results;
        }
    }
}
