import { Doughnut } from 'react-chartjs-2';
import { getTransactionsPerCategory } from '../services/statistics';
import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';

const StatisticsPage = () => {
    const dispatch = useDispatch();
    const transactionAmountPerCategory = useSelector(state =>
        state.statisticsSlice.transactionAmountPerCategory);
    const [doughnut, setDoughnut] = useState({
        labels: [],
        data: [],
    });

    useEffect(() => {
        getTransactionsPerCategory(dispatch);
    }, []);

    useEffect(() => {
        setDoughnut({
            labels: transactionAmountPerCategory.map(x => x.Key),
            data: transactionAmountPerCategory.map(x => x.Value),
        });
    }, [transactionAmountPerCategory]);

    const data = {
        labels: doughnut.labels,
        datasets: [{
            data: doughnut.data,
            backgroundColor: [
                '#007bff', // blue
                '#FF0000', // red
                '#FFD700', // yellow
                '#28a745', // green
                '#FF00FF', // violet
                '#ff9900', // orange
                '#00FFFF', // aqua marine
                '#d69ae5', // red violet
                '#FF8F66', // orange red
                '#00FF00', // lime
            ],
        }],
    };

    return <div hidden={!transactionAmountPerCategory || !transactionAmountPerCategory.length}
        style={{ maxWidth: '35rem', maxHeight: '35rem', margin: 'auto', textAlign: 'center' }}>
        <h4 style={{ marginTop: '10px' }}>Transactions per Category</h4>
        <Doughnut data={data} />
    </div>
}

export default StatisticsPage;