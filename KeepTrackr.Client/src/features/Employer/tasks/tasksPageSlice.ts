import { Build } from '@mui/icons-material';
import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { AxiosError } from 'axios';
import httpClient from '../../../app/httpClient';
import { useSelector } from 'react-redux';


interface Board {
    id: string,
    title: string,
    order: number
};

interface ReorderBoard {
    boardid: string,
    sourceOrder: number,
    destinationOrder: number,
    company: string | undefined
};

export const reorderBoard = createAsyncThunk('tasks/reorderBoard', async (board: ReorderBoard) => {

    const token = localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    };

/*    const boards = useSelector((x : any) => x.state.boards.entities);*/
    const result = httpClient.put('api/tasks/boards/order', board, config);

    return board;

});

export const addBoard = createAsyncThunk('tasks/addBoard', async (board: any, { rejectWithValue }) => {

    const token = localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    };
    try {
        httpClient.post('api/tasks/boards', { title: board.title, order: board.order, companyName: board.company } , config);
        return board;
    } catch (e : any) {
        //const error = e as AxiosError<Board>;

        //if (e.code == '409') return rejectWithValue(e.response.data);

        return rejectWithValue(e.message);
    }    
});

export const fetchAllBoards = createAsyncThunk('tasks/fetchBoards', async (company: string | undefined) => {

    const token = localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: `Bearer ${token}`
        },
        params: {
            company
        }
    };

    const result = await httpClient.get('api/tasks/boards', config);

    return result.data;
});

//const getAllTasksSelector = (state: any) => {
//    return state.tasks.boards.forEach
//};

const initialState = {
    newBoard: {
        title:""
    },
    boards: {
        ids: [],
        entities: []
    },
    cards: {
        ids: [],
        entities: []
    }
};

const slice = createSlice({
    name: 'tasks',
    reducers: {
        changeNewBoardName: (state : any, action : any) => {
            state.newBoard = action.payload;
        }
    },
    initialState: initialState,
    extraReducers(builder) {
        builder.addCase(fetchAllBoards.fulfilled, (state: any, action: any) => {
            state.boards.entities = action.payload;
        });

        builder.addCase(reorderBoard.fulfilled, (state: any, action: any) => {
            const board = state.boards.entities.find((el: any) => el.id == action.payload.boardid);

            board.order = action.payload.destinationOrder;


           /* state.boards.entities[action.payload.id].order = */
            state.boards.entities.sort((a: any, b: any) => a.order > b.order ? 1 : -1);
        });

        builder.addCase(addBoard.fulfilled, (state: any, action: any) => {
            state.boards.entities.push(action.payload);
        });

        builder.addCase(addBoard.rejected, (state: any, action: any) => {
            state.boards = state.boards.filter((value: any, index: any, arr: any) => {
                if (value.order != action.payload.order && value.name != action.payload.name) {
                    return true;
                }
                return false;
            });
        });
    }
});
export const { changeNewBoardName } = slice.actions;

export default slice.reducer;